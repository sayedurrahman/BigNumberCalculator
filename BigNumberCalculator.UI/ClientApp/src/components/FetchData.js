import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
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
    this.props.requestData();
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
              {props.datas.map(data =>
        <tr key={data.calculationDate}>
            <td>{data.calculationDate.toLocaleString('en-us')}</td>
            <td>{data.userName}</td>
            <td>{data.bigNumber1}</td>
            <td>{data.bigNumber2}</td>
            <td>{data.sum}</td>
        </tr>
        )}
      </tbody>
    </table>
  );
}

export default connect(
    state => state.calculatedDatas,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(FetchData);
