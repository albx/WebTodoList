import React, { Component } from 'react';

class AddTodo extends Component {
    static displayName = AddTodo.name;

    render() {
        return (
            <div className="col-md-12">
                <form>
                    <div className="form-row">
                        <div className="input-group mb-3">
                            <input type="text" className="form-control" placeholder="Add a task" aria-label="Add a task" aria-describedby="addTodoButton" />
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