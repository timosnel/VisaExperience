FROM buildpack-deps:trusty-scm

MAINTAINER Timo Snel

# dotnet CLI
ENV DOTNET_VERSION=1.0.0-rc2-002673
ENV LTTNG_UST_REGISTER_TIMEOUT 0

RUN echo "deb [arch=amd64] http://apt-mo.trafficmanager.net/repos/dotnet/ trusty main" > /etc/apt/sources.list.d/dotnetdev.list \
    && apt-key adv --keyserver apt-mo.trafficmanager.net --recv-keys 417A0893 \
    && apt-get update \
    && apt-get install -y --no-install-recommends dotnet-dev-${DOTNET_VERSION} \
    && rm -rf /var/lib/apt/lists/*

# Set environment variables
ENV ASPNETCORE_URLS="http://*:5000"
ENV ASPNETCORE_ENVIRONMENT="Staging"

# Required for dotnet-watch to detect file changes
ENV USE_POLLING_FILE_WATCHER=1

# Copy files to app directory
COPY . /app

# Set working directory
WORKDIR /app

# Restore NuGet packages
RUN ["dotnet", "restore"]

# Open up port
EXPOSE 5000

# Specify a url with a wildcard for the host name
ENTRYPOINT ["/bin/bash", "-c", "dotnet watch"]