import React from 'react';
import { connect } from 'react-redux';

const Home = props => (
  <div>
        <h1>Hello, world!</h1>
        <p>I am Sayedur Rahman, Principal Software Engineer with 10+ years of experiance. For more detail go to my linkedin profile. Here is the <a href="https://www.linkedin.com/in/sayedur-rahman/">link</a> </p>
  </div>
);

export default connect()(Home);
