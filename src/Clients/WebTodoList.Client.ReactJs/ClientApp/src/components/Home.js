import React, { Component } from 'react';

import AddTodo from './AddTodo';
import TodoList from './TodoList';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>My Todo List</h1>
        <div className="row">
          <AddTodo />
        </div>
        <div className="row">
          <TodoList />
        </div>
      </div>
    );
  }
}
