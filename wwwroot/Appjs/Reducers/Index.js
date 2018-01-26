import { combineReducers } from 'redux';
import SaleInvoiceReducer from './SaleInvoiceReducer';
import ToolbarReducer from './ToolbarReducer';

export default combineReducers(
    { 
        SaleInvoiceReducer, 
        ToolbarReducer 
    }
)
