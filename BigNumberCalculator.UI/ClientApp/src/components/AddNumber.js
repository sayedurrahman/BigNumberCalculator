import React from "react";
import { connect } from "react-redux";
import { addNumber } from "../store/AddNumber";

class AddNumber extends React.Component {
    constructor(props) {
        super(props);
        this.state = { input: "" };
    }

    updateInput = input => {
        this.setState({ input });
    };

    handleAddNumber = () => {
        this.props.addNumber(this.state.input);
        this.setState({ input: "" });
    };

    render() {
        return (
            <div>
                <input
                    onChange={e => this.updateInput(e.target.value)}
                    value={this.state.input}
                />
                <button className="add-todo" onClick={this.handleAddNumber}>
                    Add Number
        </button>
            </div>
        );
    }
}

export default connect(
    null,
    { addNumber }
)(AddNumber);
// export default AddNumber;
