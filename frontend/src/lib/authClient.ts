import Keycloak from "keycloak-js";

const keycloakConfig = {
  url: "https://practicek8s.westeurope.cloudapp.azure.com/",
  realm: "TestRealm",
  clientId: "test-client",
};

const keycloak = new Keycloak(keycloakConfig);

export default keycloak;
