import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/utils/Layout';
import { Home } from './pages/Home';
import CafeLogin from './pages/login/CafeLogin';
import AdminLogin from './pages/login/AdminLogin';
import AdminDashboard from './pages/admin/AdminDashboard';
import CafeDashboard from './pages/cafe/CafeDashboard';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/kafegirisi' component={CafeLogin} />
        <Route path='/adminimben' component={AdminLogin} />
        <Route path='/admin' component={AdminDashboard} />
        <Route path='/kafe' component={CafeDashboard} />
        
        {/* <Route path='/counter' component={Counter} />
        <Route path='/fetch-data' component={FetchData} /> */}
      </Layout>
    );
  }
}
