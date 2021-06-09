FROM golang:alpine as back
WORKDIR /
COPY go.sum go.mod site.go ./
COPY view ./view
RUN CGO_ENABLED=0 GOOS=linux go build -o site .
CMD ["./site"]