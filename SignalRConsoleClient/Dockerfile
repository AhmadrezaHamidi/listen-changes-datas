# Build image
ARG REPO=mcr.microsoft.com/dotnet/sdk
ARG REPORUN=mcr.microsoft.com/dotnet/aspnet
ARG POJECT_NAME=ReportProblem.Api
ARG AppName=${POJECT_NAME}.dll

FROM $REPO:3.1 AS build

WORKDIR /src

#RUN ./builder.sh
COPY projectfiles.tar .
RUN tar -xvf projectfiles.tar
RUN rm projectfiles.tar
COPY ./nuget.config ./nuget.config
RUN dotnet restore --configfile ./nuget.config
COPY ./ ./

RUN dotnet publish "./ReportProblem.Api/ReportProblem.Api.csproj" -c Release -o "/src/dist" --no-restore
RUN mv /src/CHANGELOG.md /src/dist


# app as iamge
FROM $REPORUN:3.1-alpine 

	
WORKDIR /app
COPY --from=build /src/dist ./

# Fix Globalization Error
RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV EventBus__ClientName=ReportProblemApi
EXPOSE 80
ENTRYPOINT ["dotnet", "ReportProblem.Api.dll"]


