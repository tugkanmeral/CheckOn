import * as actions from "./actionsTypes";

export const setToken = (token) => ({
    type: actions.SET_TOKEN,
    payload: token,
});

export const removeUser = () => ({
    type: actions.EMPTY_USER,
    payload: null,
});

export const setUser = (user) => ({
    type: actions.SET_USER,
    payload: user,
});

export const updateUser = (user) => ({
    type: actions.UPDATE_USER,
    payload: user,
});

