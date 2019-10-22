import React from "react";
//import { connect } from "react-redux";
import axios from 'axios';
//import { addNumber } from "../store/AddNumber";

class AddNumber extends React.Component {
    constructor(props) {
        super(props);
        this.state = { userName: '', firstNumber: '', secondNumber: '' };
    }

    changeHandler = e => {
        this.setState({ [e.target.name]: e.target.value })
    }

    submitHandler = e => {
        e.preventDefault();
        axios.post(
            'http://localhost:62007/api/Addition',
            this.state)
            .then(response => { console.log(response) })
            .catch(error => { console.log(error) })
    }

    render() {
        const { userName, firstNumber, secondNumber } = this.state
        return (
            <div>
                <form onSubmit={this.submitHandler}>
                    <input type="text" name="userName" value={userName} onChange={this.changeHandler} />
                    <input type="text" name="firstNumber" value={firstNumber} onChange={this.changeHandler}  />
                    <input type="text" name="secondNumber" value={secondNumber} onChange={this.changeHandler}  />

                    <button type="submit">Add Number</button>

                    <strong>Value1: {this.state.userName}</strong>
                    <strong>Value2: {this.state.firstNumber}</strong>
                    <strong>Value3: {this.state.secondNumber}</strong>
                </form>
            </div>
        );
    }
}

export default AddNumber;