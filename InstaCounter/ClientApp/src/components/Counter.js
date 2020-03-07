import React, { Component } from 'react';

export class Counter extends Component {
  static displayName = Counter.name;

  constructor(props) {
    super(props);
    this.state = {users: [], isLoading: true}; 
   }

 
   


  render() {
    return (
      <div>
        <h1>Oversikt</h1>

        <p>This is a simple example of a React component.</p>

        <p aria-live="polite">Current count: <strong>{this.state.users.followers}</strong></p>

      </div>
    );
  }
}
