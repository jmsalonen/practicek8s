FROM quay.io/keycloak/keycloak:24.0.4

ENV KEYCLOAK_ADMIN admin
ENV KEYCLOAK_ADMIN_PASSWORD admin
ENV KC_DB postgres
ENV KC_DB_URL_HOST postgresdb
ENV KC_DB_URL_DATABASE keycloak
ENV KC_DB_USERNAME keycloak
ENV KC_DB_PASSWORD 1234
ENV KC_HEALTH_ENABLED true
ENV KC_IMPORT /opt/keycloak/data/import/test-realm.json
ENV KC_HTTPS_PORT 8443
ENV KC_HTTPS_KEY_STORE_FILE /opt/keycloak/conf/certificates/keycloak.p12
ENV KC_HTTPS_CERTIFICATE_FILE /opt/keycloak/conf/certificates/aks-ingress-tls.crt
ENV KC_HTTPS_CERTIFICATE_KEY_FILE /opt/keycloak/conf/certificates/aks-ingress-tls.key
ENV KC_HTTPS_KEY_STORE_PASSWORD changeit
ENV KC_HTTP_ENABLED true
# ENV KC_PROXY edge
ENV KC_HOSTNAME_STRICT false
# ENV KC_HOSTNAME practicek8s.westeurope.cloudapp.azure.com
ENV KC_PROXY_HEADERS xforwarded
# ENV KC_PROXY_PROTOCOL_ENABLED true

COPY ./test-realm.json /opt/keycloak/data/import/test-realm.json

COPY ./certs /opt/keycloak/conf/certificates

EXPOSE 8080
EXPOSE 8443
EXPOSE 9000

CMD ["start", "--import-realm", "--verbose"]
