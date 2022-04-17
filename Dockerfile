FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
COPY . .
RUN dotnet publish -c release --self-contained -r linux-musl-x64 -p:PublishSingleFile=true -p:PublishReadyToRun=true -p:PublishTrimmed=true

FROM mcr.microsoft.com/dotnet/runtime-deps:6.0-alpine AS final

RUN apk add --no-cache icu-libs

COPY --from=build /app/bin/release/net6.0/linux-musl-x64/publish/MyWay /usr/local/bin/myway
COPY --from=build /app/static /static/

ENV PORT=80
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV Logging__LogLevel__Microsoft=Information

CMD [ "/usr/local/bin/myway" ]