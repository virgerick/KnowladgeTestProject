export interface Order {
  orderId: Number;
  customerId: String;
  freight: Number;
  shipCountry: String;
}
export interface OrderFilter {
  orderId?: Number;
  shipCountry?: String;
  operator: "AND" | "OR";
}
