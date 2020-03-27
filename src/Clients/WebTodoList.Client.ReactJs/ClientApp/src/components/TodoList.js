import React, { Component } from 'react';

class TodoList extends Component {
    static displayName = TodoList.name;

    state = {
        hideCompletedTask: false
    }

    markTodoItemAsDone(item) {
        const url = 'https://localhost:44387/api/todo/' + item.id + '/done';
        fetch(url, {
            headers: {
                'Content-Type': 'application/json'
            },
            method: 'PATCH',
        }).then((response) => {
            this.props.onTodoItemMarkedAsDone(item);
        }).catch((response) => {
            alert('ERROR!');
        });
    }

    deleteTodoItem(item) {
        const url = 'https://localhost:44387/api/todo/' + item.id;
        fetch(url, {
            headers: {
                'Content-Type': 'application/json'
            },
            method: 'DELETE',
        }).then((response) => {
            this.props.OnTodoItemDeleted(item);
        }).catch((response) => {
            alert('ERROR!');
        });
    }

    toggleCompletedItems() {
        const { hideCompletedTask } = this.state;
        this.setState({
            hideCompletedTask: !hideCompletedTask
        });

        this.props.onToggleCompletedItems(!hideCompletedTask);
    }

    buildTodoList = () => {
        return (
            !this.props.items ?
            <div className="alert alert-info">
                <p>Nothing to do :)</p>
            </div>
            :
            <div>
                <div className="custom-control custom-switch">
                    <input type="checkbox" className="custom-control-input" id="hideTaskIfDone" checked={this.state.hideCompletedTask} onChange={() => this.toggleCompletedItems()} />
                    <label className="custom-control-label" htmlFor="hideTaskIfDone">Hide completed task</label>
                </div>
                <hr />
                <div className="list-group">
                    {this.buildListItems(this.props.items || [])}
                </div>
            </div>
        ); 
    };

    buildListItems = (items) => {
        return items.map((i) => {
            const checkboxId = i.id + "-is-done";
            const style = i.isDone ? { textDecoration: 'line-through' } : {};

            return (
                <div className="list-group-item d-flex justify-content-between align-items-center" key={i.id}>
                    <input className="form-check-input" type="checkbox" id={checkboxId} disabled={i.isDone} defaultChecked={i.isDone} onClick={() => this.markTodoItemAsDone(i)} />
                    <label className="form-check-label" htmlFor={checkboxId} style={style}>{i.text}</label>
                    <button type="button" className="btn btn-outline-danger" title="Delete this item" onClick={() => this.deleteTodoItem(i)}>
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