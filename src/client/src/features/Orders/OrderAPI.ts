import { Order, OrderFilter } from "../../models/Order";
import { Result } from "./Result";

let NEXT_PUBLIC_API_URL: string = process.env.NEXT_PUBLIC_API_URL ?? "";
export const GetOrdersAsync = async (filter: OrderFilter) => {
  //?Filter=contains(shipCountry , 'Dom') and OrderId eq 10249
  let filterString = "";

  if (filter.orderId) {
    filterString += `contains(OrderId , '${filter.orderId}')`;
  }

  if (filter.shipCountry && filter.shipCountry.length > 0) {
    if (filterString.length > 0) {
      filterString += ` ${filter.operator} `;
    }
    filterString += `contains(shipCountry , '${filter.shipCountry}')`;
  }

  const endpoint = `${NEXT_PUBLIC_API_URL}/OData/Orders${
    filterString.length > 0 ? `?Filter=${filterString}` : ""
  }`;

  console.log(endpoint);
  const response = await fetch(endpoint, {
    method: "GET",
    headers: {
      accept: "application/json;odata.metadata=minimal;odata.streaming=true",
    },
  });
  const Order: Array<Order> = await response.json();
  return Order;
};
export const CreateOrdersAsync = async (Order: Order) => {
  const response = await fetch(`${NEXT_PUBLIC_API_URL}/Orders`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(Order),
  });
  const result: Result = await response.json();
  return result;
};
export const UpdateOrdersAsync = async (id: Number, Order: Order) => {
  const response = await fetch(`${NEXT_PUBLIC_API_URL}/Orders/${id}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(Order),
  });
  const result: Result = await response.json();
  return result;
};
export const DeleteOrdersAsync = async (id: Number) => {
  const response = await fetch(`${NEXT_PUBLIC_API_URL}/Orders/${id}`, {
    method: "DELETE",
    headers: {
      "Content-Type": "application/json",
    },
  });
  const result: Result = await response.json();
  return result;
};
