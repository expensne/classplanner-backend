set dotenv-load

DOCKER := "podman"

_default:
    just --list

# Installs dotnet's EF tool and creates db/sqlite.db
dotnet-ef-init:
    #!/bin/bash
    test -f db/sqlite.db && { echo "existing database found: db/sqlite.db"; exit 0; }

    dotnet tool install --global dotnet-ef || true
    export PATH="$PATH:/root/.dotnet/tools"

    # Error in docker:
    # Tool 'dotnet-ef' failed to update due to the following:
    # Failed to uninstall tool package 'dotnet-ef': Invalid cross-device link
    # dotnet tool update --global dotnet-ef

    dotnet ef migrations add InitialCreate
    dotnet ef database update

# Builds the project
dotnet-build:
    #!/bin/bash
    set -euxo pipefail

    dotnet build

# Starts a local http server on port 5000
dotnet-run-http:
    #!/bin/bash
    set -euxo pipefail

    dotnet run --launch-profile http

alias run := dotnet-run-http

publish:
    #!/bin/bash
    set -euxo pipefail

    dotnet clean && dotnet publish -c Release
    scp -r -i $SSH_ID bin/Release/net7.0/publish/* $SSH_DST:~/api
    scp -r -i $SSH_ID db $SSH_DST:~/api/

# Builds the docker image
docker-build:
    #!/bin/bash
    set -euxo pipefail

    {{ DOCKER }} build -t classbook-api .

# Runs the docker image and exposes port 5000
docker-run: docker-build
    #!/bin/bash
    set -euxo pipefail

    {{ DOCKER }} run -p 5000:5000 classbook-api
