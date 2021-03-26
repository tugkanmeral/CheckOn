import React, { Component } from "react";
import OlMap from "ol/Map";
import OlView from "ol/View";
import OlLayerTile from "ol/layer/Tile";
import OlLayerVector from "ol/layer/Vector";
import OLFeature from "ol/Feature";
import OLPoint from "ol/geom/Point";
import OlSourceOSM from "ol/source/OSM";
import OlSourceVector from "ol/source/Vector";
import { toLonLat, toUserCoordinate } from "ol/proj";
import "./map.css";
import Style from "ol/style/Style";
import Text from "ol/style/Text";
import Stroke from "ol/style/Stroke";
import Fill from "ol/style/Fill";
import Circle from "ol/geom/Circle";

class Map extends Component {
  constructor(props) {
    super(props);

    this.state = { center: [0, 0], zoom: 1 };

    var layerTile = new OlLayerTile({
      source: new OlSourceOSM(),
    });

    var point1 = new OLPoint([3232055.666111154, 5018171.579939838]);
    var point2 = new OLPoint([3232059.65, 5018172.57]);

    var feature1 = new OLFeature({
      geometry: point1,
      name: "Null Island",
      population: 4000,
      rainfall: 500,
    });

    var feature2 = new OLFeature({
      geometry: point2,
      name: "Null Island",
      population: 50000,
      rainfall: 100000,
    });

    var stroke = new Stroke({width: 0.8})

    var text1 = new Text({ text: "%80", stroke, scale: 2});
    var text2 = new Text({ text: "6", stroke});

    var markStyle1 = new Style({
      text: text1,
    });
    var markStyle2 = new Style({
      text: text2,
    });

    feature1.setStyle(markStyle1);
    feature2.setStyle(markStyle2);

    var sourceVector = new OlSourceVector({
      features: [feature1, feature2],
    });

    var layerVector = new OlLayerVector({
      source: sourceVector,
    });

    this.olmap = new OlMap({
      target: null,
      layers: [layerTile, layerVector],
      view: new OlView({
        center: this.state.center,
        zoom: this.state.zoom,
      }),
    });
  }

  updateMap() {
    this.olmap.getView().setCenter(this.state.center);
    this.olmap.getView().setZoom(this.state.zoom);
  }

  componentDidMount() {
    this.olmap.setTarget("map");

    // Listen to map changes
    this.olmap.on("moveend", () => {
      let center = this.olmap.getView().getCenter();
      let zoom = this.olmap.getView().getZoom();
      this.setState({ center, zoom });
    });
  }

  shouldComponentUpdate(nextProps, nextState) {
    let center = this.olmap.getView().getCenter();
    let zoom = this.olmap.getView().getZoom();
    if (center === nextState.center && zoom === nextState.zoom) return false;
    return true;
  }

  userAction() {
    // this.setState({ center: [41, 29], zoom: 5 });//41.0166666 29.0333332
    var data = this.olmap.getView().getCenter();
    console.log(data);
    var dataLonLat = toLonLat(data);
    console.log(dataLonLat);
    var dataUserCoordinate = toUserCoordinate(dataLonLat);
    console.log(dataUserCoordinate);
    console.log(this.convertCoordinates(dataLonLat[0], dataLonLat[1]));
    // this.setState({center: , zoom: 5})
  }
  userAction1() {
    this.setState({
      center: [3232060.666111154, 5018173.579939838],
      zoom: 21,
    });
  }
  userAction2() {
    this.setState({
      center: [3232060.6656612474, 5018173.579241298],
      zoom: 21,
    });
  }

  convertCoordinates(lon, lat) {
    var x = (lon * 20037508.34) / 180;
    var y = Math.log(Math.tan(((90 + lat) * Math.PI) / 360)) / (Math.PI / 180);
    y = (y * 20037508.34) / 180;
    return [x, y];
  }

  render() {
    this.updateMap(); // Update map on render?
    return (
      <div id="map" style={{ width: "100%", height: "360px" }}>
        <button onClick={(e) => this.userAction1()}>setState on click 1</button>
        <button onClick={(e) => this.userAction2()}>setState on click 2</button>
      </div>
    );
  }
}

export default Map;
