using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GA_Merge_Sort
{
    internal class Program
    {
        //EDNA LYNN LAXA
        //COMPUTER PRGOGRAMMING V 
        //ASSIGNMENT : MERGE SORT 
        //FEBRUARY 8, 2024 
        static void Main(string[] args)
        {

            // Reference Video : https://www.youtube.com/watch?v=3j0SWDX4AtU // Bro code 
            // Reference Vidoe : https://www.youtube.com/watch?v=aJVMJrgOPYc // Will's 

       
            int[] array = { 12, 11, 13, 5, 6, 7 };

            Console.WriteLine("Original Array:");
            PrintArray(array);

            MergeSort(array, 0, array.Length - 1);

            Console.WriteLine("Sorted Array:");
            PrintArray(array);

        }
        public static void MergeSort(int[] array, int left, int right)
        {
            if (left < right) // Using a bool condition to deemed if left is less than right index 
            {
                // Find the middle point
                int middle = (left + right) / 2; 
                // Declares variable "middle" as in integer. 
                //Middle will be define as the left number sum with the right number and performing a division of 2 

                // Sort first and second halves
                MergeSort(array, left, middle); // Calling the method and implementing our called parameters. 
                //Calling left & middle effectively sorts the first half of the array 

                MergeSort(array, middle + 1, right);// Calling the method and implementing our called parameters. 
                // +1 objective is based on positioning of the index or clear seperation between the first & second half of the array
                // please correct me if im wrong , i had to do research for this part to fully understand the concept of middle +1
                //This method calling basiccaly sorts the 2nd half of the array. 
                

                // Merge the sorted halves
                Merge(array, left, middle, right);// Calling the method and implementing our called parameters.
                // The aim is to merge the two sorted arrays into a single sorted array 
                //Array is OG, left is the starting index of the first half, middle is the seperation of the two and 
                //right is the second half of the array. 

            }
        }
        public static void Merge(int[] array, int left, int middle, int right)
        {
            // Implement the logic to merge two sorted subarrays into a single sorted array
            // Include comments explaining the merging process

            int n1 = middle - left + 1; // n1 is the variable used to define middle-left +1 
            //middle is define as the index in the center of the arr & left is definite as the starting part of ind. 
            //The equation results the size of the first part of the array. Subtracting from left from the middle gets the 
            //number of elements prior to the middle. 
            //Incoperating the add of 1 assist the elemnt to include itself to the array. 

            int n2 = right - middle; // n2 is the variable used to define right-middle 
            //right is define as the ending index of the array and again, middle is the center. 
            //The equeation is to subtract the middle index from the end point of the index. 

            // Create temporary arrays
            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            //Place holders for the two arrays of left & right 

            //Left array will be fully define what is held by n1 which is the reuslt of middle - left + 1 
            //rightArray will be fully deemed as what is concluded for right-middle 

            // Copy data to temp arrays leftArray[] and rightArray[]
            for (int i = 0; i < n1; i++) //USING FOR LOOP to go through each element in the first part of the array
                //hence reason why left array partakes in this coding. Left Array is define as the inital section of the array. 
                leftArray[i] = array[left + i]; // The focal part on this is positioning. This will correspond to the left array index 

            for (int j = 0; j < n2; j++) // USING FOR LOOP to go through each element in the 2nd half of the array. 
                rightArray[j] = array[middle + 1 + j];// Code for positioning generally. This implements the OG part of the array 
            // to position that second half of the array to index j. 

            int k = left; //variable K is defined as left which will prompt the index in the OG array to where it will be placed. 
            int x = 0, y = 0; //Now 2 variables comes to play , both definited as null. 

            // Merge the temp arrays back into array[left..right]
            while (x < n1 && y < n2) // A while loop comes in play to continue its objective of x<n1  && y <n2. 
                //This basically means that there are remaining elements in left and right 
            {
                if (leftArray[x] <= rightArray[y]) // A comparison is then conditioned the first part of the array is < / equal to right array. 
                {
                    array[k] = leftArray[x];// array k = left array is basically the location of elment from left array
                    //is seeking placement in the origianl array at the current index. ?? 
                    x++; //variable x moves to the next element in the first part of the array , which is left 
                }
                else
                {
                    array[k] = rightArray[y]; //if the first condition does not apply then right array will be into current index k 

                    y++; // move element in the right array which is what y is 
                }
                k++; // the elment is incremented for index k to queue the next position fo the original array 
            }

            // Copy the remaining elements of leftArray[], if there are any
            while (x < n1) // If there are elments in the left array that's left 
            {
                array[k] = leftArray[x]; // current elments on the left side to transition to index k which i OG 
                x++; //x moves to the next elemnt in the left side 
                k++;//k moves to the next placement in the OG array 

                //x = left 
                //k = OG 
            }

            // Copy the remaining elements of rightArray[], if there are any
            while (y < n2) // condition to continue looping if there are still elements left in the right side 
            {
                array[k] = rightArray[y]; //Current element on the rigth side will be definie in the original index 
                y++; // elmeents on the right sdie will be move to the next element 
                k++; // this will move the nexxt placement in the OG array. 
            }
        }
        public static void PrintArray(int[] array)
        {
            foreach (var item in array) // Using for each to loop in the array itself. 
            {
                Console.Write(item + " "); // This will display it all 
            }
            Console.WriteLine();
        }





        //***********************************************
    public static class SortMerge
    {
        public static T[] Sort<T>(T[] arr) where T : IComparable<T>
        {
            if (arr.Length <= 1)
            {
                return arr;
            }

            int middle = arr.Length / 2;
            T[] left = new T[middle];
            T[] right = new T[arr.Length - middle];

            Array.Copy(arr, 0, left, 0, middle);
            Array.Copy(arr, middle, right, 0, arr.Length - middle);

            left = Sort(left);
            right = Sort(right);

            return Merge(left, right);
        }

        private static T[] Merge<T>(T[] left, T[] right) where T : IComparable<T>
        {
            T[] result = new T[left.Length + right.Length];
            int leftIndex = 0, rightIndex = 0, resultIndex = 0;

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex].CompareTo(right[rightIndex]) < 0)
                {
                    result[resultIndex++] = left[leftIndex++];
                }
                else
                {
                    result[resultIndex++] = right[rightIndex++];
                }
            }

            Array.Copy(left, leftIndex, result, resultIndex, left.Length - leftIndex);
            Array.Copy(right, rightIndex, result, resultIndex, right.Length - rightIndex);

            return result;
        }
    }



}
}
