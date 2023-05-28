import { ChangeEvent, useEffect, useState } from "react";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import IconButton from "@mui/material/IconButton";
import SearchIcon from "@mui/icons-material/Search";
import FormControl from "@mui/material/FormControl";
import InputLabel from "@mui/material/InputLabel";
import Select from "@mui/material/Select";
import MenuItem from "@mui/material/MenuItem";
import { useAppDispatch, useAppSelector, useForm } from "../../hooks";
import { OrderFilter } from "../../models/Order";
import { searchOrders, setFilters } from "./OrderSlice";

function SearchOrders() {
  const dispatch = useAppDispatch();
  const filters: OrderFilter = useAppSelector((state) => state.order.filters);
  const [form, setForm] = useState<OrderFilter>();
  const onSubmitHandler = async (content: OrderFilter) => {
    await dispatch(setFilters(content));
    await dispatch(searchOrders(filters));
  };

  const formHandler = useForm<OrderFilter>(filters)(onSubmitHandler);
  useEffect(() => {
    dispatch(searchOrders(filters));
  }, []);

  const onFieldChangeHandler = (
    event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    const name = event.target.name;
    const value = event.target.value;
    dispatch(setFilters({ ...filters, [`${name}`]: value }));
  };
  return (
    <form
      onSubmit={formHandler}
      style={{
        width: "100%",
        display: "flex",
        flexDirection: "row",
        flexWrap: "wrap",
        gap: "1rem",
        padding: 10,
      }}
    >
      <TextField
        label="Order ID"
        type="number"
        name="orderId"
        variant="outlined"
        onChange={onFieldChangeHandler}
      />
      <TextField
        label="Ship Country"
        type="text"
        name="shipCountry"
        variant="outlined"
        onChange={onFieldChangeHandler}
      />
      <FormControl variant="outlined">
        <InputLabel>Operator</InputLabel>
        <Select
          name="operator"
          defaultValue="AND"
          label="Operator"
          onChange={(e) =>
            onFieldChangeHandler(e as ChangeEvent<HTMLInputElement>)
          }
        >
          <MenuItem value="AND">AND</MenuItem>
          <MenuItem value="OR">OR</MenuItem>
        </Select>
      </FormControl>
      <Button type="submit" variant="contained" color="primary">
        <SearchIcon /> Search
      </Button>
    </form>
  );
}
export default SearchOrders;
