import React from "react";
import axios from 'axios';

class AddNumber extends React.Component {
    constructor(props) {
        super(props);
        this.state = { userName: '', firstNumber: '', secondNumber: '', problemSet: '', result: '' };
    }

    changeHandler = e => {
        this.setState({ [e.target.name]: e.target.value })
    }

    submitHandler = e => {
        e.preventDefault();
        axios.post(
            'http://localhost:62007/api/Addition',
            this.state)
            .then(
                response => {
                    this.setState({ result: "Result =" + response.data })
                })
            .catch(error => { console.log(error) })

        this.setState({ userName: '', firstNumber: '', secondNumber: '' })
    }

    render() {
        const { userName, firstNumber, secondNumber, problemSet, result } = this.state
        return (
            <div>
                <h1>Do the Math!</h1>
                <form onSubmit={this.submitHandler}>
                    <p>
                    <label>User Name:</label><br />
                        <input type="text" name="userName" value={userName} onChange={this.changeHandler} className="form-control" />
                    
                    </p>
                    <p>
                        <label>
                            First Number:</label><br />
                        <input type="text" name="firstNumber" value={firstNumber} onChange={this.changeHandler} className="form-control" />
                    </p>
                    <p>
                        <label>
                            Second Number:</label><br />
                        <input type="text" name="secondNumber" value={secondNumber} onChange={this.changeHandler} className="form-control" />
                    </p>
                    
                    <p>
                        <button className="btn btn-primary" type="submit">Submit</button>
                    </p>
                    <p>{problemSet}</p>
                    <p>{result}</p>
                </form>
            </div>
        );
    }
}

export default AddNumber;