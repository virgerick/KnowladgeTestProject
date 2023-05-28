import type { NextPage } from "next";
import Head from "next/head";

import Counter from "../features/counter/Counter";
import styles from "../styles/Home.module.css";
import { SpreadsheetComponent } from "@syncfusion/ej2-react-spreadsheet";

const IndexPage: NextPage = () => {
  return (
    <div className="p-5">
      <SpreadsheetComponent
        saveUrl="https://localhost:7014/api/Spreadsheet/save"
        openUrl="https://services.syncfusion.com/react/production/api/spreadsheet//Open"
      />
    </div>
  );
};

export default IndexPage;
