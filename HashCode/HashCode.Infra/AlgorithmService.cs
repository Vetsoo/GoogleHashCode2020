﻿using HashCode.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HashCode.Infra
{
    public class AlgorithmService
    {

        private Input _input = null;

        public AlgorithmService(Input input)
        {
            _input = input;
        }

        public Output RunAlgorithm1()
        {
            List<MaxThroughputLibrary> maxThrouhgputItem = new List<MaxThroughputLibrary>();
            foreach (var library in _input.Libraries)
            {


                var daysToScan = _input.Days - library.SignUpProcess;
                var scannableBooks = daysToScan * library.BooksPerDay;

                if (scannableBooks > library.AmountOfBooks)
                {
                    scannableBooks = library.AmountOfBooks;
                }

                maxThrouhgputItem.Add(new MaxThroughputLibrary
                {
                    LibraryId = library.LibraryId,
                    Throughput = scannableBooks
                });
            }

            maxThrouhgputItem.OrderByDescending(x => x.Throughput);

            var output = new Output();
            output.LibraryAndBooksOrder = new List<System.Tuple<int, int[]>>();

            foreach (var outputLine in maxThrouhgputItem)
            {
                output.LibraryAndBooksOrder.Add(new System.Tuple<int, int[]>(
                    outputLine.LibraryId,
                    _input.Libraries.Single(x => x.LibraryId == outputLine.LibraryId).BookIds.ToArray()
                    )); ;
            }

            return output;
        }
        public Output RunAlgorithmNumberOne()
        {
            List<CalculatedLibrary> inputLibraries = new List<CalculatedLibrary>();
            List<CalculatedLibrary> inputLibrariesWithoutMultiples = new List<CalculatedLibrary>();
            foreach (var library in _input.Libraries)
            {
                inputLibraries.Add(new CalculatedLibrary() { AmountOfBooks = library.AmountOfBooks, BookIds = library.BookIds, SignUpProcess = library.SignUpProcess, TotalTimeNeeded = library.SignUpProcess + library.AmountOfBooks / library.BooksPerDay, LibraryId = library.LibraryId });

            }
            var sorted = inputLibraries.OrderBy(x => x.SignUpProcess).OrderByDescending(x => x.TotalTimeNeeded).ToList();
            List<Tuple<int, int[]>> tuple = new List<Tuple<int, int[]>>();
            List<int> bookIds = new List<int>();

            foreach (var sort in sorted)
            {
                var amount = sort.BookIds.Except(bookIds).Count();
                if (amount <= (sort.AmountOfBooks / 2))
                {
                    inputLibrariesWithoutMultiples.Add(sort);
                }
                bookIds.AddRange(sort.BookIds);
            }

            foreach (var sort in inputLibrariesWithoutMultiples)
            {
                tuple.Add(new Tuple<int, int[]>(sort.LibraryId, sort.BookIds.ToArray()));
            }
            return new Output()
            {
                LibraryAndBooksOrder = tuple
            };
        }

    }
}
