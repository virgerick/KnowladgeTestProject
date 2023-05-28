import type { NextPage } from "next";
import {
  ColumnDirective,
  ColumnsDirective,
  GridComponent,
} from "@syncfusion/ej2-react-grids";
import {
  Edit,
  EditSettingsModel,
  Inject,
  Toolbar,
  ToolbarItems,
} from "@syncfusion/ej2-react-grids";
import { Order, OrderFilter } from "../models/Order";
import { useAppDispatch, useAppSelector } from "../hooks";
import SearchOrders from "../features/Orders/SearchOrders";
import {
  searchOrders,
  AddOrderAsync,
  EditOrderAsync,
  DeleteOrderAsync,
} from "../features/Orders/OrderSlice";
import { MessageComponent } from "@syncfusion/ej2-react-notifications";

const EditPage: NextPage = () => {
  const filters: OrderFilter = useAppSelector((state) => state.order.filters);
  const dispatch = useAppDispatch();
  const Orders: Array<Order> = useAppSelector((state) => state.order.Orders);
  const message = useAppSelector((state) => state.order.messages);
  const editOptions: EditSettingsModel = {
    allowEditing: true,
    allowAdding: true,
    allowDeleting: true,
    mode: "Normal",
  };
  const toolbarOptions: ToolbarItems[] = [
    "Add",
    "Edit",
    "Delete",
    "Update",
    "Cancel",
  ];
  const actionBegin = async (args: any) => {
    console.log(args);
    let data = args.data;
    if (args.requestType == "beginEdit") {
    }
    if (args.requestType == "delete") {
      args.cancel = true;
      await dispatch(DeleteOrderAsync(data[0].orderId));
      await dispatch(searchOrders(filters));
    }
    if (args.requestType == "add") {
    }
    if (args.requestType == "save") {
      args.cancel = true;
      switch (args.action) {
        case "add": {
          await dispatch(AddOrderAsync(data));
          await dispatch(searchOrders(filters));
          break;
        }
        case "edit": {
          await dispatch(EditOrderAsync(data));
          await dispatch(searchOrders(filters));
          break;
        }

        default: {
          break;
        }
      }
    }
  };

  return (
    <>
      <SearchOrders />
      <div>
        <GridComponent
          dataSource={Orders}
          editSettings={editOptions}
          toolbar={toolbarOptions}
          actionBegin={actionBegin}
          height={750}
        >
          <ColumnsDirective>
            <ColumnDirective
              field="OrderId"
              headerText="Order ID"
              width="100"
              textAlign="Right"
              isPrimaryKey={true}
            />
            <ColumnDirective
              field="CustomerId"
              headerText="Customer ID"
              width="120"
            />
            <ColumnDirective
              field="Freight"
              headerText="Freight"
              width="120"
              format="C2"
              editType="numericedit"
              textAlign="Right"
            />
            <ColumnDirective
              field="ShipCountry"
              headerText="Ship Country"
              editType="dropdownedit"
              width="150"
            />
          </ColumnsDirective>
          <Inject services={[Edit, Toolbar]} />
        </GridComponent>
        {message && message.length > 0 && (
          <MessageComponent content={message} showCloseIcon />
        )}
      </div>
    </>
  );
};

export default EditPage;
