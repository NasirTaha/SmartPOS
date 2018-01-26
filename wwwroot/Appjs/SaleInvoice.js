//import { Router, Route, IndexRoute, hashHistory } from 'react-router';
import { BrowserRouter, Route } from 'react-router-dom'
import SaleInvoiceLayout from './Components/SaleInvoice/SaleInvoiceLayout';


import { Provider } from 'react-redux';
import store from './Store';



store.subscribe(() => {
    console.log('store subscribe()', store.getState());

});
store.dispatch({ type: "SEARCH_ITEM", payload: "Taha"});
ReactDOM.render(
    <Provider store={store}>
        <SaleInvoiceLayout />
    </Provider>
    ,
    document.getElementById('testReact')
);

//<BrowserRouter>
//    <Route path="/" component={SaleInvoiceLayout} />
//</BrowserRouter>


//import CommentBox from './Components/CommentBox';

//ReactDOM.render((
//    <BrowserRouter>
//        <Route path="/" component={CommentBox} />
//    </BrowserRouter>
//    ),
//    document.getElementById('testReact')
//);