import * as actions from "../actions/actionsTypes";

const userReducer = (
  state = {
    id: null,
    email: null,
  },
  action
) => {
  var newState = null;
  switch (action.type) {
    case actions.SET_TOKEN:
      newState = {
        ...state,
        token: action.payload,
      };
      return newState;
      
    case actions.SET_USER:
      newState = action.payload;
      return newState;

    case actions.EMPTY_USER:
      newState = {
        id: null,
        email: null,
        name: null,
        surname: null,
        token: null,
        userName: null,
        active: null,
        roleId: null,
        role: null,
      };
      return newState;

    case actions.UPDATE_USER:
      newState = {
        ...state,
        email: action.payload.email,
        name: action.payload.name,
        surname: action.payload.surname,
      };
      return newState;

    default:
      return state;
  }
};
export default userReducer;
