import React, { Component } from 'react';

import AddTodo from './AddTodo';
import TodoList from './TodoList';

import ListItemViewModel from '../viewModels/ListItemViewModel';

export class Home extends Component {
  static displayName = Home.name;

  state = {
    todos: null
  };

  hideIfDone = false;

  componentDidMount() {
    this.loadTodoItems();
  }

  loadTodoItems(hideIfDone) {
    hideIfDone = hideIfDone || false;

    let url = 'https://localhost:44387/api/todo';
    if (hideIfDone) {
      url += '?hideIfDone=true';
    }

    fetch(url)
      .then((response) => response.json())
      .then((items) => items.map(item => ListItemViewModel.map(item.id, item.text, item.isDone)))
      .then((items) => {
        this.setState({ todos: items });
      });
  }

  markItemAsDone(item) {
    let todoItems = this.state.todos.slice();
    const itemIndex = todoItems.findIndex(i => i.id === item.id);
    if (itemIndex !== -1) {
      todoItems[itemIndex].isDone = true;
      if (this.hideIfDone) {
        todoItems = todoItems.filter(i => i.id !== item.id);
      }
    }

    this.setState({ todos: todoItems });
  }

  removeItem(item) {
    const todoItems = this.state.todos.slice().filter(i => i.id !== item.id);
    this.setState({ todos: todoItems });
  }

  toggleCompletedItems(hideCompletedItems) {
    this.hideIfDone = hideCompletedItems;
    this.loadTodoItems(hideCompletedItems);
  }

  render () {
    return (
      <div>
        <h1>My Todo List</h1>
        <div className="row">
          <AddTodo onNewTodoItemAdded={() => this.loadTodoItems()} />
        </div>
        <div className="row">
          <TodoList items={this.state.todos} 
                    onTodoItemMarkedAsDone={(item) => this.markItemAsDone(item)}
                    OnTodoItemDeleted={(item) => this.removeItem(item)}
                    onToggleCompletedItems={(hideCompletedItems) => this.toggleCompletedItems(hideCompletedItems)} />
        </div>
      </div>
    );
  }
}
