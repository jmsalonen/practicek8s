import React from 'react';
import './App.css';
import { ReactKeycloakProvider } from '@react-keycloak/web';
import authClient from './lib/authClient';

// @ts-ignore
import logo from './logo.svg';

const App: React.FC = () => {
  return (
    // @ts-ignore
    <ReactKeycloakProvider
      authClient={authClient}
      initOptions={{
        onLoad: 'login-required',
      }}
      LoadingComponent={<h2>Loading</h2>}
    >
      <div>
        <h1>Hello WEB</h1>
      </div>
    </ReactKeycloakProvider>
  )
}

export default App;
