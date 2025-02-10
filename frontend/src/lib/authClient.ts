import Keycloak from "keycloak-js";

const keycloakConfig = {
  url: "http://localhost/",
  realm: "TestRealm",
  clientId: "test-client",
};

const keycloak = new Keycloak(keycloakConfig);

export default keycloak;
