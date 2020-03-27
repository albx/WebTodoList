import React, { Component } from 'react';

import NewTodoViewModel from '../viewModels/NewTodoViewModel';

class AddTodo extends Component {
    static displayName = AddTodo.name;

    state = {
        newTodoText: ''
    };

    handleNewTodoChange(text) {
        this.setState({
            newTodoText: text
        });
    }

    handleSubmit(evt) {
        evt.preventDefault();
        
        const { newTodoText } = this.state;

        let newTodoItemViewModel = new NewTodoViewModel(newTodoText);

        fetch('https://localhost:44387/api/todo', {
            headers: {
                'Content-Type': 'application/json'
            },
            method: 'POST',
            body: JSON.stringify(newTodoItemViewModel)
        }).then((response) => {
            this.setState({
                newTodoText: ''
            });

            this.props.onNewTodoItemAdded();
        }).catch((response) => {
            alert('ERROR!');
        })
    }

    render() {
        return (
            <div className="col-md-12">
                <form onSubmit={(evt) => this.handleSubmit(evt)}>
                    <div className="form-row">
                        <div className="input-group mb-3">
                            <input type="text" value={this.state.newTodoText} onChange={(evt) => this.handleNewTodoChange(evt.target.value)} className="form-control" placeholder="Add a task" aria-label="Add a task" aria-describedby="addTodoButton" />
                            <div className="input-group-append">
                                <button className="btn btn-outline-secondary" type="submit" id="addTodoButton">
                                    <span className="oi oi-plus" aria-hidden="true"></span>
                                    Add new
                                </button>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        );
    }
}

export default AddTodo;