import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import FetchData from './components/FetchData';
import AddNumber from './components/AddNumber';

export default () => (
  <Layout>
    <Route exact path='/' component={Home} />
    <Route path='/add-number' component={AddNumber} />
    <Route path='/fetch-data/:startDateIndex?' component={FetchData} />
  </Layout>
);
