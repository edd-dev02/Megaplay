FROM node:20.19-bookworm AS builder
WORKDIR /app
COPY ..
RUN npm install && npm run build

# Servidor
FROM nginx:stable
COPY --from=builder /app/dist/megaplay /usr/share/nginx/html
EXPOSE 40
CMD ["nginx", "-g", "daemon off;"]

