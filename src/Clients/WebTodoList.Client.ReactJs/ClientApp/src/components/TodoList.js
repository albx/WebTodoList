import React, { Component } from 'react';

class TodoList extends Component {
    static displayName = TodoList.name;

    buildTodoList = () => {
        return (
            !this.props.items ?
            <div className="alert alert-info">
                <p>Nothing to do</p>
            </div>
            :
            <div className="list-group">
                {this.buildListItems(this.props.items || [])}
            </div>
        ); 
    };

    buildListItems = (items) => {
        return items.map((i) => {
            let checkboxId = i.id + "-is-done";
            return (
                <div className="list-group-item d-flex justify-content-between align-items-center" key={i.id}>
                    <input className="form-check-input" type="checkbox" id={checkboxId} />
                    <label className="form-check-label" htmlFor={checkboxId}>{i.text}</label>
                    <button type="button" className="btn btn-outline-danger" title="Delete this item">
                        <span>X</span>
                        <span className="sr-only">Delete</span>
                    </button>
                </div>
            );
        })
    };

    render() {
        const todoList = this.buildTodoList();
        return (
            <div className="col-md-12">
                {todoList}
            </div>
        );
    }
}

export default TodoList;