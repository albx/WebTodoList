import React, { Component } from 'react';

import AddTodo from './AddTodo';
import TodoList from './TodoList';

export class Home extends Component {
  static displayName = Home.name;

  state = {
    todos: null
  };

  componentDidMount() {
    this.loadTodoItems();
  }

  loadTodoItems() {
    fetch('https://localhost:44387/api/todo')
      .then((response) => response.json())
      .then((items) => {
        this.setState({ todos: items });
      });
  }

  render () {
    return (
      <div>
        <h1>My Todo List</h1>
        <div className="row">
          <AddTodo />
        </div>
        <div className="row">
          <TodoList items={this.state.todos} />
        </div>
      </div>
    );
  }
}
