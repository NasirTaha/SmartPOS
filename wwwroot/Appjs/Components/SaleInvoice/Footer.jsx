

export default class Footer extends React.Component {
    constructor() {
        super();
        this.state = {
        };
    }

    
    render() {
        return (
            <div className="invoice-footer">
                <div className="row">

                    <div className="col-sm-7">
                        <div className="payment-methods">
                            <h5>Payment Methods</h5>

                            <img src="/img/invoice/paypal.png" width="64" height="64" alt="paypal" />
                                <img src="/img/invoice/americanexpress.png" width="64" height="64" alt="american express" />
                                    <img src="/img/invoice/mastercard.png" width="64" height="64" alt="mastercard" />
                                        <img src="/img/invoice/visa.png" width="64" height="64" alt="visa" />
                                                </div>
                                            </div>
                                    <div className="col-sm-5">
                                        <div className="invoice-sum-total pull-right">
                                            <h3><strong>المجموع شامل الضريبة: <span className="text-success">95 ريال سعودي</span></strong></h3>
                                        </div>
                                    </div>

                                        </div>

                                <div className="row">
                                    <div className="col-sm-12">
                                        <p className="note">**To avoid any excess penalty charges, please make payments within 30 days of the due date. There will be a 2% interest charge per month on all late invoices.</p>
                                    </div>
                                </div>

                                    </div>
            );
    }
}