import Keycloak from "keycloak-js";

const keycloakConfig = {
  url: "http://keycloakauth:8080/",
  realm: "asiakas3",
  clientId: "asiakas3",
};

const keycloak = new Keycloak(keycloakConfig);

export default keycloak;
