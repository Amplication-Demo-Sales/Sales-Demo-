import * as React from "react";
import { Edit, SimpleForm, EditProps, TextInput } from "react-admin";

export const AddressEdit = (props: EditProps): React.ReactElement => {
  return (
    <Edit {...props}>
      <SimpleForm>
        <TextInput label="City" source="city" />
        <TextInput label="Country" source="country" />
        <TextInput label="PostalCode" source="postalCode" />
        <TextInput label="State" source="state" />
        <TextInput label="Street" source="street" />
      </SimpleForm>
    </Edit>
  );
};
