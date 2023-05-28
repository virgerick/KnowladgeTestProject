import { createAsyncThunk, createSlice, PayloadAction } from "@reduxjs/toolkit";
import type { AppState, AppThunk } from "../../store";
import { Order, OrderFilter } from "../../models/Order";
import {
  CreateOrdersAsync,
  DeleteOrdersAsync,
  GetOrdersAsync,
  UpdateOrdersAsync,
} from "./OrderAPI";

export interface OrderState {
  filters: OrderFilter;
  Orders: Array<Order>;
  status: "idle" | "loading" | "failed";
  messages: String;
}
const initialState: OrderState = {
  filters: { operator: "AND" },
  Orders: [],
  status: "idle",
  messages: "",
};

export const searchOrders = createAsyncThunk(
  "Order/search",
  async (filter: OrderFilter) => {
    const response: Array<Order> = await GetOrdersAsync(filter);

    return response;
  }
);
export const AddOrderAsync = createAsyncThunk(
  "Order/add",
  async (request: Order) => {
    const response = await CreateOrdersAsync(request);

    return response;
  }
);
export const EditOrderAsync = createAsyncThunk(
  "Order/edit",
  async (request: Order) => {
    const response = await UpdateOrdersAsync(request.orderId, request);

    return response;
  }
);
export const DeleteOrderAsync = createAsyncThunk(
  "Order/delete",
  async (orderId: Number) => {
    const response = await DeleteOrdersAsync(orderId);
    return response;
  }
);

export const OrderSlice = createSlice({
  name: "Order",
  initialState,
  reducers: {
    setFilters: (state, action: PayloadAction<OrderFilter>) => {
      state.filters = action.payload;
    },
    setOrders: (state, action: PayloadAction<Array<Order>>) => {
      state.Orders = action.payload;
    },
    AddOrder: (state, action: PayloadAction<Order>) => {
      state.Orders.push(action.payload);
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(searchOrders.pending, (state) => {
        state.status = "loading";
      })
      .addCase(searchOrders.fulfilled, (state, action) => {
        state.status = "idle";
        state.Orders = action.payload;
      })
      .addCase(AddOrderAsync.pending, (state) => {
        state.status = "loading";
      })
      .addCase(AddOrderAsync.fulfilled, (state, action) => {
        state.status = action.payload.succeeded ? "idle" : "failed";
        state.messages = action.payload.message;
      })
      .addCase(EditOrderAsync.pending, (state) => {
        state.status = "loading";
      })
      .addCase(EditOrderAsync.fulfilled, (state, action) => {
        state.status = action.payload.succeeded ? "idle" : "failed";
        state.messages = action.payload.message;
      })
      .addCase(DeleteOrderAsync.pending, (state) => {
        state.status = "loading";
      })
      .addCase(DeleteOrderAsync.fulfilled, (state, action) => {
        state.status = action.payload.succeeded ? "idle" : "failed";
        state.messages = action.payload.message;
      });
  },
});
export const { setFilters, AddOrder } = OrderSlice.actions;

export const selectFilters = (state: AppState) => state.Order.filters;
export const selectOrders = (state: AppState) => state.Order.Orders;
export const selectStatus = (state: AppState) => state.Order.status;
export const selectMessages = (state: AppState) => state.Order.messages;

export default OrderSlice.reducer;
