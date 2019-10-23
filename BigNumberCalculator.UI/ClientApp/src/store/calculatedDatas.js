const requestDataType = 'REQUEST_DATA';
const receiveDataType = 'RECEIVE_DATA';
const initialState = { datas: [], isLoading: false };

export const actionCreators = {
  requestData: () => async (dispatch, getState) => {
    dispatch({ type: requestDataType });
    dispatch({ type: requestDataType });

    const url = 'http://localhost:62007/api/Result';
    const response = await fetch(url);
    const datas = await response.json();

    dispatch({ type: receiveDataType, datas });
  }
};

export const reducer = (state, action) => {
  state = state || initialState;

  if (action.type === requestDataType) {
    return {
      ...state,
      isLoading: true
    };
  }

  if (action.type === receiveDataType) {
    return {
      ...state,
        datas: action.datas,
      isLoading: false
    };
  }

  return state;
};
