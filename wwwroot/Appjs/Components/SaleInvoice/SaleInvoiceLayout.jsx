import Body from './Body';
import Footer from './Footer';
import Toolbar from './Toolbar';


export default class SaleInvoiceLayout extends React.Component {
    constructor() {
        super();
        this.state = {
            items: [
                {
                    id: 1,
                    name: "name1",
                    price: 24.00,
                    qty: 3,
                    total: 48.52
                },
                {
                    id: 2,
                    name: "name2",
                    price: 24.00,
                    qty: 3,
                    total: 48.52
                }
            ]
        };
    }
    render() {
        return (
            <div className="widget-body no-padding">
                <div className="padding-10">
                    <Toolbar />
                    <Body items={this.state.items} />
                   <Footer />
                </div>
            </div>
        );
    }
}