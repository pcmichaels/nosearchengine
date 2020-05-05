import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { AddSite } from './components/AddSite';
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';
import { AddSiteSuccess } from './components/AddSiteSuccess';
import { AddSiteFailure } from './components/AddSiteFailure';
import { Approval } from './components/Approval';

import './custom.css'
import 'bootstrap/dist/css/bootstrap.css'
import { MySites } from './components/MySites';

export default class App extends Component {
  static displayName = App.name;        

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />        
        <AuthorizeRoute path='/addSite' component={AddSite} />
        <AuthorizeRoute path='/addSiteSuccess' component={AddSiteSuccess} />
        <AuthorizeRoute path='/addSiteFailure/:reason' component={AddSiteFailure} />
        <AuthorizeRoute path='/mySites' component={MySites} />        
        <AuthorizeRoute path='/approval' component={Approval} />        
        <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />

      </Layout>
    );
  }
}