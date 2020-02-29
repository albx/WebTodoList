import React, { Component } from 'react';

class TodoList extends Component {
    static displayName = TodoList.name;

    render() {
        return (
            <div className="col-md-12">
                <div className="alert alert-info">
                    <p>Nothing to do</p>
                </div>
            </div>
        );
    }
}

export default TodoList;