import React, { Component } from 'react';

export class Counter extends Component {
  static displayName = Counter.name;

  constructor(props) {
    super(props);
    this.state = { cafes: [], loading: true };
  }

  componentDidMount() {
    this.getCafeDatas();
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Counter.renderCafeTable(this.state.cafes);

    return (
      <div>
        <h1 id="tabelLabel" >Cafe Bilgileri</h1>
        {contents}
      </div>
    );
  }

  static renderCafeTable = (_cafes) => {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>ID</th>
            <th>Name</th>
          </tr>
        </thead>
        <tbody>
          {_cafes.map(cafe =>
            <tr key={cafe.id}>
              <td>{cafe.id}</td>
              <td>{cafe.name}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  getCafeDatas = async () => {
    const response = await fetch('api/cafes');
    const data = await response.json();
    this.setState({ cafes: data, loading: false });
  }
}
