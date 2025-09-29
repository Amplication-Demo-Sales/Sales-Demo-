import * as React from "react";
import { Create, SimpleForm, CreateProps, TextInput } from "react-admin";

export const AddressCreate = (props: CreateProps): React.ReactElement => {
  return (
    <Create {...props}>
      <SimpleForm>
        <TextInput label="City" source="city" />
        <TextInput label="Country" source="country" />
        <TextInput label="PostalCode" source="postalCode" />
        <TextInput label="State" source="state" />
        <TextInput label="Street" source="street" />
      </SimpleForm>
    </Create>
  );
};
