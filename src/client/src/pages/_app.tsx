import "../styles/globals.css";
import { Provider } from "react-redux";
import type { AppProps } from "next/app";
import { registerLicense } from "@syncfusion/ej2-base";

import store from "../store";
let syncfusionKey: string = process.env.NEXT_PUBLIC_SyncfusionKey ?? "";
registerLicense(syncfusionKey);
export default function MyApp({ Component, pageProps }: AppProps) {
  return (
    <Provider store={store}>
      <Component {...pageProps} />
    </Provider>
  );
}
