import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { actionCreators } from '../store/WeatherForecasts';

class FetchData extends Component {
  componentDidMount() {
    // This method is called when the component is first added to the document
    this.ensureDataFetched();
  }

  componentDidUpdate() {
    // This method is called when the route parameters change
    this.ensureDataFetched();
  }

  ensureDataFetched() {
    const startDateIndex = parseInt(this.props.match.params.startDateIndex, 10) || 0;
    this.props.requestWeatherForecasts(startDateIndex);
  }

  render() {
    return (
      <div>
        <h1>Number Calculations</h1>
        <p>Fetching data from the server</p>
        {renderForecastsTable(this.props)}
      </div>
    );
  }
}

function renderForecastsTable(props) {
  return (
    <table className='table table-striped'>
      <thead>
        <tr>
            <th>Calculation Date</th>
            <th>User Name</th>
            <th>Big Number 1</th>
            <th>Big Number 2</th>
            <th>Sum</th>
        </tr>
      </thead>
      <tbody>
        {props.forecasts.map(forecast =>
        <tr key={forecast.calculationDate}>
                <td>{forecast.calculationDate.toLocaleString('en-us')}</td>
            <td>{forecast.userName}</td>
            <td>{forecast.bigNumber1}</td>
            <td>{forecast.bigNumber2}</td>
            <td>{forecast.sum}</td>
        </tr>
        )}
      </tbody>
    </table>
  );
}

function renderPagination(props) {
  const prevStartDateIndex = (props.startDateIndex || 0) - 5;
  const nextStartDateIndex = (props.startDateIndex || 0) + 5;

  return <p className='clearfix text-center'>
    <Link className='btn btn-default pull-left' to={`/fetch-data/${prevStartDateIndex}`}>Previous</Link>
    <Link className='btn btn-default pull-right' to={`/fetch-data/${nextStartDateIndex}`}>Next</Link>
    {props.isLoading ? <span>Loading...</span> : []}
  </p>;
}

export default connect(
  state => state.weatherForecasts,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(FetchData);
