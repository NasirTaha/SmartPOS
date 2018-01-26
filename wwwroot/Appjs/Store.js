import { applyMiddleware, createStore } from 'redux';
import reducers from './Reducers/Index';
import logger from 'redux-logger';


 const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;
 export default  createStore(reducers, /* preloadedState, */ composeEnhancers(
    applyMiddleware(logger)
  ));

//export default createStore(reducers, applyMiddleware(logger));