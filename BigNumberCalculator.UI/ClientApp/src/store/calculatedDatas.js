const requestWeatherForecastsType = 'REQUEST_WEATHER_FORECASTS';
const receiveWeatherForecastsType = 'RECEIVE_WEATHER_FORECASTS';
const initialState = { datas: [], isLoading: false };

export const actionCreators = {
  requestWeatherForecasts: () => async (dispatch, getState) => {
    dispatch({ type: requestWeatherForecastsType });

    const url = 'http://localhost:62007/api/Result';
    const response = await fetch(url);
    const datas = await response.json();

    dispatch({ type: receiveWeatherForecastsType, datas });
  }
};

export const reducer = (state, action) => {
  state = state || initialState;

  if (action.type === requestWeatherForecastsType) {
    return {
      ...state,
      startDateIndex: action.startDateIndex,
      isLoading: true
    };
  }

  if (action.type === receiveWeatherForecastsType) {
    return {
      ...state,
      startDateIndex: action.startDateIndex,
        datas: action.datas,
      isLoading: false
    };
  }

  return state;
};
