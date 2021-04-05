import "../../styles/components/cafe/cafeList.css";

import React, { Component } from "react";
import { GetCafeList } from "../../services/CafeService";
import { Button } from "primereact/button";
import { InputText } from "primereact/inputtext";
import * as ConvertUtils from "../../services/ConvertUtils";
import { ProgressBar } from "primereact/progressbar";
import { IoLocationSharp } from "react-icons/io5";
import Loading from "../utils/Loading";
import * as Colors from "../../utils/Colors";
import { Slider } from "primereact/slider";

export class CafeList extends Component {
  constructor(props) {
    super(props);
    this.state = {
      cafes: [],
      filteredCafes: [],
      page: 0, // zero-based
      numberOfItem: 6,
      cafeNameFilter: "",
      cafeAddress: "",
      occupancyRange: [0, 100],
    };
  }

  componentDidMount = () => {
    this.GetCafes();
  };

  render() {
    var startIndex = this.state.page * this.state.numberOfItem;
    var endIndex =
      this.state.page * this.state.numberOfItem + this.state.numberOfItem;
    var pageItems = this.state.filteredCafes.slice(startIndex, endIndex);

    var nextPage = !(
      this.state.filteredCafes.length >
      (this.state.page + 1) * this.state.numberOfItem
    );
    var prevPage = this.state.page <= 0;

    return (
      <div id="cafe-list-container">
        <div id="filter-container" className="tm-shadow-high">
          <InputText
            type="text"
            value={this.state.cafeName}
            onChange={(e) => this.SearchCafeName(e)}
            className="p-inputtext-sm p-d-block p-mb-2"
            placeholder="Mekan"
          />
          <InputText
            type="text"
            value={this.state.address}
            onChange={(e) => this.SearchAddress(e)}
            className="p-inputtext-sm p-d-block p-mb-2"
            placeholder="Bölge"
          />
          <Slider
            value={this.state.occupancyRange}
            onChange={(e) => this.SetRangeValues(e.value)}
            range
          />
        </div>
        <div className="cafe-list-grid">
          {this.state.cafes.length <= 0 ? (
            <Loading />
          ) : (
            this.RenderCafeRows(pageItems)
          )}
        </div>
        <div id="nav-btn-container">
          <Button
            disabled={prevPage}
            onClick={this.PrevPage}
            className="p-button-raised p-button-text"
            label="Önceki"
            icon="pi pi-arrow-left"
            iconPos="left"
          />
          <Button
            disabled={nextPage}
            onClick={this.NextPage}
            className="p-button-raised p-button-text"
            label="Sonraki"
            icon="pi pi-arrow-right"
            iconPos="right"
          />
        </div>
      </div>
    );
  }

  RenderCafeRows = (_pageItems) => {
    var cafeListRows = [];
    for (let i = 0; i < _pageItems.length; i++) {
      var occupancy = _pageItems[i].occupancy * 100;
      var progressColor = "";
      if (occupancy < 33) progressColor = Colors.GREEN;
      else if (occupancy < 66) progressColor = Colors.YELLOW;
      else progressColor = Colors.RED;
      const element = (
        <div className="cafe-list-row tm-shadow" key={i}>
          <div className="tm-col-5">{_pageItems[i].name}</div>
          <div className="tm-col-3">
            <div className="address-container">
              <IoLocationSharp size="1.5rem" />
              {_pageItems[i].address}
            </div>
          </div>
          <div className="tm-col-4">
            <ProgressBar
              value={occupancy}
              color={progressColor}
              showValue={false}
            />
          </div>
        </div>
      );
      cafeListRows.push(element);
    }
    return cafeListRows;
  };

  GetCafes = async () => {
    var cafeList = await GetCafeList().then((data) => {
      return data;
    });
    this.setState({ cafes: cafeList.obj, filteredCafes: cafeList.obj });
  };

  PrevPage = () => {
    var page = this.state.page === 0 ? 0 : this.state.page - 1;
    this.setState({ page });
  };

  NextPage = () => {
    var page =
      this.state.filteredCafes.length <=
      (this.state.page + 1) * this.state.numberOfItem
        ? this.state.page
        : this.state.page + 1;
    this.setState({ page });
  };

  SetRangeValues = (values) => {
    this.setState({ occupancyRange: [values[0], values[1]] });
    var filteredCafes = this.state.cafes.filter(
      (cafe) =>
        ConvertUtils.toTrLowerCase(cafe.name).includes(
          ConvertUtils.toTrLowerCase(this.state.cafeNameFilter)
        ) &&
        ConvertUtils.toTrLowerCase(cafe.address).includes(
          ConvertUtils.toTrLowerCase(this.state.cafeAddress)
        ) &&
        cafe.occupancy * 100 >= values[0] &&
        cafe.occupancy * 100 < values[1]
    );
    this.setState({ filteredCafes, page: 0 });
  };

  SearchCafeName = (e) => {
    var cafeName = e.target.value;
    this.setState({ cafeNameFilter: cafeName });
    var filteredCafes = this.state.cafes.filter(
      (cafe) =>
        ConvertUtils.toTrLowerCase(cafe.name).includes(
          ConvertUtils.toTrLowerCase(cafeName)
        ) &&
        ConvertUtils.toTrLowerCase(cafe.address).includes(
          ConvertUtils.toTrLowerCase(this.state.cafeAddress)
        ) &&
        cafe.occupancy * 100 >= this.state.occupancyRange[0] &&
        cafe.occupancy * 100 < this.state.occupancyRange[1]
    );
    this.setState({ filteredCafes, page: 0 });
  };

  SearchAddress = (e) => {
    var address = e.target.value;
    this.setState({ cafeAddress: address });
    var filteredCafes = this.state.cafes.filter(
      (cafe) =>
        ConvertUtils.toTrLowerCase(cafe.name).includes(
          ConvertUtils.toTrLowerCase(this.state.cafeNameFilter)
        ) &&
        ConvertUtils.toTrLowerCase(cafe.address).includes(
          ConvertUtils.toTrLowerCase(address)
        ) &&
        cafe.occupancy * 100 >= this.state.occupancyRange[0] &&
        cafe.occupancy * 100 < this.state.occupancyRange[1]
    );
    this.setState({ filteredCafes, page: 0 });
  };
}
