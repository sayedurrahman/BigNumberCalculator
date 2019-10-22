import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { actionCreators } from '../store/calculatedDatas';

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
    this.props.requestWeatherForecasts();
  }

  render() {
    return (
      <div>
        <h1>Number Calculations</h1>
        <p>Fetching data from the server</p>
        {renderCalculatedTable(this.props)}
      </div>
    );
  }
}

function renderCalculatedTable(props) {
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
              {props.datas.map(forecast =>
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

export default connect(
  state => state.weatherForecasts,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(FetchData);
