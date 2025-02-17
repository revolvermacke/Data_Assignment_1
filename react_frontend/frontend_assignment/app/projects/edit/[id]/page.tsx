"use client";

import React, { useEffect, useState } from "react";
import { useParams, useRouter } from "next/navigation";
import { useForm, useFieldArray } from "react-hook-form";
import {
  Form,
  FormField,
  FormItem,
  FormLabel,
  FormControl,
  FormMessage,
} from "@/components/ui/form";
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";
import {
  Select,
  SelectContent,
  SelectGroup,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";

// API Endpoints
const PROJECT_API = "https://localhost:7124/api/project";
const EMPLOYEE_API = "https://localhost:7124/api/employee";
const CUSTOMER_API = "https://localhost:7124/api/customer";
const SERVICE_API = "https://localhost:7124/api/service";

// Hårdkodade statusar
const statuses = [
  { id: 1, name: "Pågående" },
  { id: 2, name: "Ej påbörjad" },
  { id: 3, name: "Avslutad" },
];

// Interfaces
interface Employee {
  id: number;
  firstName: string;
  lastName: string;
}

interface Customer {
  id: number;
  customerName: string;
}

interface AvailableService {
  id: number;
  name: string;
  price: number;
  unit: string;
}

interface SelectedService {
  serviceId: string; // vald tjänsts ID som sträng
  quantity: number;
  price: number; // hämtas automatiskt från availableServices vid val
}

interface ProjectFormData {
  title: string;
  endDate: string;
  employeeNameId: string;
  customerNameId: string;
  statusTypeId: string;
  services: SelectedService[];
}

export default function EditProjectPage() {
  const router = useRouter();
  const params = useParams();
  const projectId = params.id;

  const form = useForm<ProjectFormData>({
    defaultValues: {
      title: "",
      endDate: "",
      employeeNameId: "",
      customerNameId: "",
      statusTypeId: "",
      services: [], // Tjänster för projektet
    },
  });

  // useFieldArray för dynamiska tjänstfält
  const { fields, append, remove } = useFieldArray({
    control: form.control,
    name: "services",
  });

  const [employees, setEmployees] = useState<Employee[]>([]);
  const [customers, setCustomers] = useState<Customer[]>([]);
  const [availableServices, setAvailableServices] = useState<
    AvailableService[]
  >([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  // Hämta anställda, kunder och tjänster
  useEffect(() => {
    const fetchData = async () => {
      try {
        const [employeeRes, customerRes, serviceRes] = await Promise.all([
          fetch(EMPLOYEE_API).then((res) => res.json()),
          fetch(CUSTOMER_API).then((res) => res.json()),
          fetch(SERVICE_API).then((res) => res.json()),
        ]);

        setEmployees(employeeRes.data || []);
        setCustomers(customerRes.data || []);
        setAvailableServices(serviceRes.data || []);
      } catch (err) {
        console.error("❌ Kunde inte hämta alternativ från API:", err);
        setError("Kunde inte hämta anställda, kunder eller tjänster.");
      }
    };

    fetchData();
  }, []);

  // Hämta projektdata för att fylla i formuläret
  useEffect(() => {
    const fetchProject = async () => {
      try {
        const res = await fetch(`${PROJECT_API}/${projectId}`);
        if (!res.ok) {
          throw new Error("Kunde inte hämta projektet");
        }
        const result = await res.json();
        const project = result.data;

        // Sätt värden i formuläret
        form.setValue("title", project.title);
        form.setValue("endDate", project.endDate);
        form.setValue(
          "employeeNameId",
          project.employeeNameId?.toString() || ""
        );
        form.setValue(
          "customerNameId",
          project.customerNameId?.toString() || ""
        );
        form.setValue("statusTypeId", project.statusTypeId?.toString() || "");

        // Sätt tjänster om projektet har några
        if (project.services && Array.isArray(project.services)) {
          form.setValue("services", project.services);
        }
      } catch (err) {
        console.error("❌ Kunde inte hämta projektdata:", err);
        setError("Kunde inte hämta projektdata.");
      } finally {
        setLoading(false);
      }
    };

    fetchProject();
  }, [projectId, form]);

  const onSubmit = async (data: ProjectFormData) => {
    try {
      const response = await fetch(`${PROJECT_API}/${projectId}`, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
      });

      if (!response.ok) {
        throw new Error("Kunde inte uppdatera projektet.");
      }
      router.push("/projects"); // eller router.back()
    } catch (err) {
      console.error("❌ Fel vid uppdatering av projekt:", err);
      setError("Ett fel inträffade vid uppdatering av projektet.");
    }
  };

  if (loading) return <p>Laddar projektdata...</p>;
  if (error) return <p className="text-red-500">{error}</p>;

  return (
    <Form {...form}>
      <form
        onSubmit={form.handleSubmit(onSubmit)}
        className="space-y-4 max-w-lg mx-auto p-6 bg-white shadow-md rounded-lg"
      >
        <h1 className="text-3xl font-bold mb-4">Redigera Projekt</h1>

        {/* Projekttitel */}
        <FormField
          control={form.control}
          name="title"
          rules={{ required: "Projekttitel är obligatoriskt" }}
          render={({ field }) => (
            <FormItem>
              <FormLabel>Projekttitel</FormLabel>
              <FormControl>
                <Input placeholder="Ange projekttitel" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        {/* Slutdatum */}
        <FormField
          control={form.control}
          name="endDate"
          rules={{ required: "Slutdatum är obligatoriskt" }}
          render={({ field }) => (
            <FormItem>
              <FormLabel>Slutdatum</FormLabel>
              <FormControl>
                <Input type="date" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        {/* Projektansvarig */}
        <FormField
          control={form.control}
          name="employeeNameId"
          rules={{ required: "Vänligen välj en projektansvarig" }}
          render={({ field }) => (
            <FormItem>
              <FormLabel>Projektansvarig</FormLabel>
              <FormControl>
                <Select onValueChange={field.onChange} value={field.value}>
                  <SelectTrigger>
                    <SelectValue placeholder="Välj ansvarig" />
                  </SelectTrigger>
                  <SelectContent className="bg-white text-black border border-gray-300 shadow-lg z-50">
                    <SelectGroup>
                      {employees.map((emp) => (
                        <SelectItem key={emp.id} value={emp.id.toString()}>
                          {`${emp.firstName} ${emp.lastName}`}
                        </SelectItem>
                      ))}
                    </SelectGroup>
                  </SelectContent>
                </Select>
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        {/* Kund */}
        <FormField
          control={form.control}
          name="customerNameId"
          rules={{ required: "Vänligen välj en kund" }}
          render={({ field }) => (
            <FormItem>
              <FormLabel>Kund</FormLabel>
              <FormControl>
                <Select onValueChange={field.onChange} value={field.value}>
                  <SelectTrigger>
                    <SelectValue placeholder="Välj kund" />
                  </SelectTrigger>
                  <SelectContent className="bg-white text-black border border-gray-300 shadow-lg z-50">
                    <SelectGroup>
                      {customers.map((cust) => (
                        <SelectItem key={cust.id} value={cust.id.toString()}>
                          {cust.customerName}
                        </SelectItem>
                      ))}
                    </SelectGroup>
                  </SelectContent>
                </Select>
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        {/* Status */}
        <FormField
          control={form.control}
          name="statusTypeId"
          rules={{ required: "Vänligen välj en status" }}
          render={({ field }) => (
            <FormItem>
              <FormLabel>Status</FormLabel>
              <FormControl>
                <Select onValueChange={field.onChange} value={field.value}>
                  <SelectTrigger>
                    <SelectValue placeholder="Välj status" />
                  </SelectTrigger>
                  <SelectContent className="bg-white text-black border border-gray-300 shadow-lg z-50">
                    <SelectGroup>
                      {statuses.map((status) => (
                        <SelectItem
                          key={status.id}
                          value={status.id.toString()}
                        >
                          {status.name}
                        </SelectItem>
                      ))}
                    </SelectGroup>
                  </SelectContent>
                </Select>
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        {/* Tjänster */}
        <div>
          <h3 className="text-xl font-semibold mt-4">Tjänster</h3>
          {fields.map((field, index) => (
            <div
              key={field.id}
              className="flex flex-col space-y-2 border p-2 rounded mb-2"
            >
              {/* Dropdown för att välja tjänst */}
              <FormField
                control={form.control}
                name={`services.${index}.serviceId` as const}
                rules={{ required: "Vänligen välj en tjänst" }}
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Tjänst</FormLabel>
                    <FormControl>
                      <Select
                        onValueChange={(value) => {
                          field.onChange(value);
                          // Hitta vald tjänst i availableServices
                          const foundSvc = availableServices.find(
                            (svc) => svc.id === parseInt(value)
                          );
                          if (foundSvc) {
                            // Sätt priset automatiskt (utan att visa ett separat prisfält)
                            form.setValue(
                              `services.${index}.price`,
                              foundSvc.price
                            );
                          }
                        }}
                        value={field.value}
                      >
                        <SelectTrigger>
                          <SelectValue placeholder="Välj tjänst" />
                        </SelectTrigger>
                        <SelectContent className="bg-white text-black border border-gray-300 shadow-lg z-50">
                          <SelectGroup>
                            {availableServices.map((svc) => (
                              <SelectItem
                                key={svc.id}
                                value={svc.id.toString()}
                              >
                                {svc.name} ({svc.unit}, {svc.price} SEK)
                              </SelectItem>
                            ))}
                          </SelectGroup>
                        </SelectContent>
                      </Select>
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />

              {/* Input för antal */}
              <FormField
                control={form.control}
                name={`services.${index}.quantity` as const}
                rules={{ required: "Ange antal" }}
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Antal</FormLabel>
                    <FormControl>
                      <Input
                        type="number"
                        placeholder="Ange antal"
                        {...field}
                      />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />

              <Button variant="destructive" onClick={() => remove(index)}>
                Ta bort tjänst
              </Button>
            </div>
          ))}
          <Button
            onClick={() => append({ serviceId: "", quantity: 1, price: 0 })}
          >
            Lägg till tjänst
          </Button>
        </div>

        {/* Felmeddelande */}
        {error && <p className="text-red-500">{error}</p>}

        {/* Knappar */}
        <div className="flex space-x-2">
          <Button type="submit">Spara ändringar</Button>
          <Button onClick={() => router.back()}>Tillbaka</Button>
        </div>
      </form>
    </Form>
  );
}
