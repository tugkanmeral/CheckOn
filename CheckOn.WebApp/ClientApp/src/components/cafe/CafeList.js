import React, { Component } from "react";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";
import { GetCafeList } from "../../services/CafeService";

export class CafeList extends Component {
  constructor(props) {
    super(props);
    this.state = {
      cafes: [],
    };
  }

  componentDidMount = () => {
    this.GetCafes();
  };

  render() {
    console.table(this.state.cafes)
    return (
      <div>
        CafeList
        <DataTable value={this.state.cafes}>
          <Column field="name" header="Kafe"></Column>
          <Column field="occupancy" header="Doluluk oranı" sortable></Column>
        </DataTable>
      </div>
    );
  }

  GetCafes = async () => {
    var test = await GetCafeList().then((data) => {
      return data;
    });
    this.setState({ cafes: test.obj });
  };
}
