import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { AddSite } from './components/AddSite';
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';


import './custom.css'
import 'bootstrap/dist/css/bootstrap.css'

export default class App extends Component {
  static displayName = App.name;
        /*
        When authentication is working then replace the route with this
        <AuthorizeRoute path='/mySites' component={MySites} />

        Add these when ready:
        <Route path='/mySites' component={MySites} />
        <Route path='/myProfile' component={MyProfile} />

        */

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />        
        <Route path='/addSite' component={AddSite} />
        <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />

      </Layout>
    );
  }
}
